import { Component, OnInit } from '@angular/core';
import { BreakpointService } from './core/breakpoint.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';

  constructor(
    public breakpoint: BreakpointService
  ) {}

  ngOnInit() {
    
  }
}
