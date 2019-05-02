import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { PeopleSearchComponent } from "./Components/PeopleSearch.Component";
import { SearchBoxComponent } from "./Components/Searchbox.Component";
import { SearchResultComponent } from "./Components/SearchResult.Component";
import { PeopleServices } from "./Services/PeopleServices";
import { HttpModule } from "@angular/http";
//import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    // AppComponent,
    PeopleSearchComponent,
    SearchBoxComponent,
    SearchResultComponent
  ],
  imports: [
    /*
    RouterModule.forRoot([
      { path: '', redirectTo: 'search', pathMatch: 'full' },
      { path: 'search', component: PeopleSearchComponent},
      { path: 'photoupload', component: PhotoUploadComponent },
    ]),*/
    BrowserModule,
    HttpModule
  ],
  providers: [{ provide: PeopleServices, useClass: PeopleServices }],
  bootstrap: [PeopleSearchComponent]
})
export class AppModule {}
