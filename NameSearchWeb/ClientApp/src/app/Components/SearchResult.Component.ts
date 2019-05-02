import { Component, OnInit, Inject } from "@angular/core";
import PersonProfile from "../Models/PeopleProfile";
import { PeopleServices } from "../Services/PeopleServices";

@Component({
  inputs: ["result"],
  selector: "search-result",
  template: `
    <div class="container">
      <div class="row">
        <div class="col-xs-6 px-1 ml-3  bg-primary text-white">
          <h5>{{ result.Name }} (Age:{{ result.Age }})</h5>

          <h6>Address:{{ result.Address }}</h6>
        </div>
        <div class="col-xs-6" style="height:160px;">
          <div>
            <div *ngIf="hasImage">
              <img
                id="{{ result.Id }}"
                src="{{ result.ThumbNailURI }}"
                width="200"
                height="160"
              />
            </div>
            <div *ngIf="!hasImage">
              <img
                id="{{ result.Id }}"
                src="https://localhost:44310/photos/noimage.jpg"
                width="200"
                height="160"
              />
            </div>
          </div>
        </div>
        <div>
          <input
            class="float-right"
            width="100"
            #imageInput
            type="file"
            accept="image/jpeg"
            (change)="processFile(imageInput)"
          />
        </div>
      </div>
    </div>
  `
})
export class SearchResultComponent implements OnInit {
  result!: PersonProfile;
  hasImage: boolean;
  selectedFile: ImageSnippet;

  constructor(@Inject(PeopleServices) public peopleService: PeopleServices) {}

  ngOnInit() {
    this.hasImage = this.result.PicturePath != null;
  }

  processFile(imageInput: any) {
    const file: File = imageInput.files[0];

    const reader = new FileReader();

    reader.addEventListener("load", (event: any) => {
      this.selectedFile = new ImageSnippet(event.target.result, file);

      this.peopleService
        .uploadImage(this.selectedFile.file, this.result.PhotoUploadURI)
        .subscribe(
          res => {
            console.log("res", res);

            console.log("blah", this.result.ThumbNailURI);

            document
              .getElementById(`${this.result.Id}`)
              .setAttribute("src", res["_body"]);
          },
          err => {}
        );
    });

    if (file.type != "image/jpeg") alert("please select a jpeg image");
    else reader.readAsDataURL(file);
  }
}

class ImageSnippet {
  constructor(public src: string, public file: File) {}
}
