import {
  Component,
  EventEmitter,
  OnInit,
  Inject,
  ElementRef
} from "@angular/core";
import PersonProfile from "../Models/PeopleProfile";
import { PeopleServices } from "../Services/PeopleServices";
import { fromEvent } from "rxjs";
import { map, filter, debounceTime, tap, switchAll } from "rxjs/operators";

@Component({
  outputs: ["loading", "results"],
  selector: "search-box",
  template: `
    <input
      type="text"
      class="d-inline mx-6"
      placeholder="Search by name"
      autofocus
    />
  `
})
export class SearchBoxComponent implements OnInit {
  loading: EventEmitter<boolean> = new EventEmitter<boolean>();
  results: EventEmitter<PersonProfile[]> = new EventEmitter<PersonProfile[]>();

  constructor(
    @Inject(PeopleServices) public peopleService: PeopleServices,
    private el: ElementRef
  ) {}
  ngOnInit(): void {
    fromEvent(this.el.nativeElement, "keyup")
      .pipe(
        map((e: any) => e.target.value),
        filter((text: string) => text.length > 1),
        debounceTime(400),
        tap(() => this.loading.next(true)),
        map((query: string) => this.peopleService.search(query)),
        switchAll()
      )
      .subscribe(
        (results: PersonProfile[]) => {
          this.loading.next(false);
          this.results.next(results);
        },
        (err: any) => {
          console.log("error:", err);
          this.loading.next(false);
        },
        () => {
          this.loading.next(false);
        }
      );
  }
}
