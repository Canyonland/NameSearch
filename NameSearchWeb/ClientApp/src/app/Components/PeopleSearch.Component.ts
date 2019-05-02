import { Component } from "@angular/core";
import PersonProfile from "../Models/PeopleProfile";

@Component({
  selector: "app-root",
  template: `
    <div style="text-align:center">
      <h1>Welcome to {{ title }}!</h1>
      <div class="">
        <div class="">
          <div>
            <search-box
              (loading)="loading = $event"
              (results)="updateResults($event)"
              (notfound)="notfound = $event"
            ></search-box>

            <div *ngIf="loading">loading...</div>
            <h2 *ngIf="notfound">not found</h2>
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
  title = "People Search App";
  notfound: boolean;
  loading: boolean;
  results!: PersonProfile[];
  updateResults(results: PersonProfile[]): void {
    this.results = results;
  }
}
