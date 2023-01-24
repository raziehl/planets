import { Component, OnInit } from '@angular/core';
import { HttpService } from '../core/http.service';

@Component({
  selector: 'app-crews',
  templateUrl: './crews.component.html',
  styleUrls: ['./crews.component.scss']
})
export class CrewsComponent implements OnInit {

  constructor(
    private http: HttpService
  ) {}

  async ngOnInit() {
    console.log(await this.http.crews());
  }

}
