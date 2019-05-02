import { Component, OnInit, Inject } from "@angular/core";
import PersonProfile from "../Models/PeopleProfile";
import { PeopleServices } from "../Services/PeopleServices";

@Component({
  inputs: ["result"],
  selector: "search-result",
  template: `
    <div class="d-inline-flex m-3 text-white">
      <div class="col-xs-6   bg-primary text-white" style="width: 200px;">
        <h6>{{ result.Name }} (Age:{{ result.Age }})</h6>

        {{ result.Address }}
        Interested in:
        <ul>
          <li *ngFor="let interest of result.Interests">{{ interest }}</li>
        </ul>
      </div>

      <div class="col-xs-6" style="height:160px;">
        <img
          *ngIf="hasImage"
          id="{{ result.Id }}"
          src="{{ result.ThumbNailURI }}"
          width="200"
          height="160"
        />

        <img
          *ngIf="!hasImage"
          id="{{ result.Id }}"
          src="https://localhost:44310/assets/photos/noimage.jpg"
          width="200"
          height="160"
        />
      </div>

      <div class="col-xs-6 text-white" style="width: 300px;">
        <input
          #imageInput
          type="file"
          accept="image/jpeg"
          (change)="processFile(imageInput)"
        />
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
