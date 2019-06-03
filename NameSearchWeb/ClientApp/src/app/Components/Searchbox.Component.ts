import {
  Component,
  EventEmitter,
  OnInit,
  Inject,
  ElementRef,
  OnDestroy
} from "@angular/core";
import PersonProfile from "../Models/PeopleProfile";
import { PeopleServices } from "../Services/PeopleServices";
import { fromEvent, of, Subscription, Observable } from "rxjs";
import {
  map,
  filter,
  debounceTime,
  tap,
  switchAll,
  catchError
} from "rxjs/operators";

@Component({
  outputs: ["loading", "results", "error"],
  selector: "search-box",
  template: `
    <div>
      <input
        type="text"
        class="span6 input-large search-query form-control"
        placeholder="Search by name. Type ALL to see all people."
        autofocus
      />
    </div>
  `
})
export class SearchBoxComponent implements OnInit, OnDestroy {
  loading: EventEmitter<boolean> = new EventEmitter<boolean>();
  results: EventEmitter<PersonProfile[]> = new EventEmitter<PersonProfile[]>();
  error: EventEmitter<string> = new EventEmitter<string>();
  subscription: Subscription;
  constructor(
    @Inject(PeopleServices) public peopleService: PeopleServices,
    private el: ElementRef
  ) {}

  ngOnInit(): void {
    let observable: Observable<string | PersonProfile[]>;

    let keyupObservabe: Observable<boolean> = fromEvent(
      this.el.nativeElement,
      "keyup"
    ).pipe(
      map((e: any) => e.target.value),
      debounceTime(400)
    );

    keyupObservabe.subscribe(() => {
      this.results.next(null);
      this.error.next(null);
    });

    observable = keyupObservabe.pipe(
      filter((text: string) => text.length > 2),
      tap(() => {
        this.loading.next(true);
      }),
      map((query: string) => this.peopleService.search(query)),
      //catchError(error => {
      // return of(error)
      //}),
      switchAll()
    );

    this.subscription = observable.subscribe(
      (results: PersonProfile[]) => {
        this.loading.next(false);
        if (typeof results === "object") {
          this.results.next(results);
        }
        else {
          this.error.next(results);
        }
      }
      //,
      //(err: any) => {
      //  console.log("error:", err);
      //  this.loading.next(false);
      //  this.error.next(true);
      //  this.results.next(null);
      //},
      //() => {
      //  this.loading.next(false);
      //  console.log("Complete");
      //}
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
