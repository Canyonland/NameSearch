import { Injectable, Inject } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable, of, throwError } from "rxjs";
import {
  map,
  filter,
  debounceTime,
  catchError,
  switchAll,
  tap
} from "rxjs/operators";
import PersonProfile from "../Models/PeopleProfile";

@Injectable()
export class PeopleServices {
  apiUrl = "https://localhost:44310/api/people";
  //photosUrl = "https://localhost:44310/assets/photos";
  constructor(public http: Http) {}

  uploadImage(image: File, queryUrl: string): Observable<Response> {
    const formData = new FormData();

    formData.append("file", image);

    return this.http.post(queryUrl, formData);
  }

  search(name: string): Observable<PersonProfile[] | string> {
    if (name.toLowerCase() === "bad")
      return of("invalid name");

    if (name.toLowerCase() === "all") {
      name = "";
    }
    let queryUrl: string = `${this.apiUrl}?name=${name}`;

    return this.http.get(queryUrl).pipe(
      catchError(error => {
        return of(error);
      }) // this catchError is important
      ,
      map((response: Response) => {
        switch (response.status) {
          case 200: 
          return (<any>response.json()).map(item => {
            return new PersonProfile({
              Id: item.id,
              Name: item.name,
              Address: item.address,
              Age: item.age,
              PicturePath: item.picturePath,
              PhotoUploadURI: item.photoUploadURI,
              ThumbNailURI: item.photoURI,
              Interests: item.interests
            });
          });
          case 404:
            return "not found";
          default:
           return "server error";
        }
        
      })
    );
  }
}
