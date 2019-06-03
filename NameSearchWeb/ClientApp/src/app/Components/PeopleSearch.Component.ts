import { Component } from "@angular/core";
import PersonProfile from "../Models/PeopleProfile";

@Component({
  selector: "app-root",
  template: `
    <div>
      <h1 style="text-align:center">Welcome to {{ title }}!</h1>
      <div class="">
        <div class="">
          <div>
            <search-box
              (loading)="loading = $event"
              (results)="updateResults($event)"
              (error)="error = $event"
            ></search-box>

            <div *ngIf="loading" style="text-align:center">loading...</div>
            <h2 *ngIf="error" style="text-align:center">{{error}}</h2>
          </div>
        </div>
      </div>
      <div class="row">
        <search-result
          *ngFor="let result of results"
          [result]="result"
        ></search-result>
      </div>
    </div>
  `
})
export class PeopleSearchComponent {
  //this is the main component
  title = "People Search App";
  error: string;
  loading: boolean;
  results!: PersonProfile[];
  updateResults(results: PersonProfile[]): void {
    this.results = results;
  }
}
