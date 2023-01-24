import { Injectable, OnInit } from '@angular/core';
import { distinctUntilChanged, tap } from 'rxjs';
import { BreakpointObserver, Breakpoints, BreakpointState } from '@angular/cdk/layout';


@Injectable({
  providedIn: 'root'
})
export class BreakpointService {
  isHandset: boolean = true;

  constructor(
    private breakpointObserver: BreakpointObserver
  ) {
    this.breakpointObserver
    .observe([Breakpoints.Small, Breakpoints.Handset])
    .subscribe((state: BreakpointState) => {
      if(state.matches) {
        this.isHandset = true;
      } else {
        this.isHandset = false;
      }
    });
  }

}
