import { Component } from "@angular/core";
import PersonProfile from "../Models/PeopleProfile";

@Component({
  selector: "app-root",
  template: `
    <div style="text-align:center">
      <h1>Welcome to {{ title }}!</h1>
      <div class="containter">
        <div class="page-header">
          <search-box
            class=" mx-30 "
            (loading)="loading = $event"
            (results)="updateResults($event)"
          ></search-box>

          <div *ngIf="loading">loading...</div>
        </div>
      </div>
    </div>
    <div class="row my-3">
      <search-result
        *ngFor="let result of results"
        [result]="result"
      ></search-result>
    </div>
  `
})
export class PeopleSearchComponent {
  title = "People Search App";
  loading: boolean;
  results!: PersonProfile[];
  updateResults(results: PersonProfile[]): void {
    this.results = results;
    console.log("peoplesearch.results", this.results);
  }
}
