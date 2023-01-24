import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Planet } from 'src/models/planet.model';
import { AuthService } from '../core/auth.service';
import { HttpService } from '../core/http.service';

@Component({
  selector: 'app-edit-planet',
  templateUrl: './edit-planet.component.html',
  styleUrls: ['./edit-planet.component.scss']
})
export class EditPlanetComponent implements OnInit {
  planet?: Planet;
  planetForm: FormGroup;
  creationMode: boolean = false;

  fileToUpload?: File;
  imageSource?: string;

  constructor(
    private http: HttpService,
    private auth: AuthService
  ) {
    this.planetForm = new FormGroup({
      planetName: new FormControl('', [
        Validators.required
      ]),
      description: new FormControl('', [
        Validators.required
      ])
    });
  }

  ngOnInit() {
    if(!this.planet) {
      this.creationMode = true;
      this.planet = new Planet();
    } else {
      this.planetName?.setValue(this.planet.name);
      this.description?.setValue(this.planet.description);
    }
  }

  get planetName() {
    return this.planetForm.get('planetName');
  }

  get description() {
    return this.planetForm.get('description');
  }

  async onSubmit() {
    if(this.planetForm.valid) {
      (this.planet as Planet).name = this.planetName?.value;
      (this.planet as Planet).description = this.description?.value;

      console.log(this.planet);

      if(this.creationMode) {
        this.http.createPlanet(this.planet as Planet);
      } else {
        this.http.updatePlanet(this.planet as Planet);
      }
    }
  }

  openFilePicker() {
    (window as any).showOpenFilePicker()
  }

  readImage(file: File) {
    // Check if the file is an image.
    if (file.type && !file.type.startsWith('image/')) {
      console.log('File is not an image.', file.type, file);
      return;
    }
  
    const reader = new FileReader();
    reader.addEventListener('load', (event) => {
      (this.planet as any).image = event.target?.result as string;
    });

    reader.readAsDataURL(file);
  }

  async onFileSelected(event: any) {
    this.fileToUpload = event.target.files[0];
    this.readImage(this.fileToUpload as File);
  }

}
