import { Injectable, Inject } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs";
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
  photosUrl = "https://localhost:44310/photos";
  constructor(public http: Http) {}

  uploadImage(image: File, queryUrl: string): Observable<Response> {
    const formData = new FormData();

    formData.append("file", image);

    return this.http.post(queryUrl, formData);
  }

  search(name: string): Observable<PersonProfile[]> {
    let queryUrl: string = `${this.apiUrl}?name=${name}`;

    return this.http.get(queryUrl).pipe(
      map((response: Response) => {
        if (response.status === 200) {
          return (<any>response.json()).map(item => {
            console.log(item);
            return new PersonProfile({
              Id: item.id,
              Name: item.name,
              Address: item.address,
              Age: item.age,
              PicturePath: item.picturePath,
              PhotoUploadURI: item.photoUploadURI,
              ThumbNailURI: `${this.photosUrl}/${item.picturePath}.jpg`,
              Interests: item.interests
            });
          });
        } else {
          throw new Error("calling serviee failed.");
        }
      })
    );
  }
}
