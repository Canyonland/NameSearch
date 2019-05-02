export default class PersonProfile {
  Id: number;
  Name: string;
  Address: string;
  Age: number;
  PicturePath: string;
  PhotoUploadURI: string;
  ThumbNailURI: string;
  Interests: string[];
  constructor(obj?: any) {
    this.Id = obj.Id;
    this.Name = obj.Name;
    this.Address = obj.Address;
    this.Age = obj.Age;
    this.PicturePath = obj.PicturePath;
    this.ThumbNailURI = obj.ThumbNailURI;
    this.PhotoUploadURI = obj.PhotoUploadURI;
    this.Interests = obj.Interests;
  }
}
