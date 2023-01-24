import { Component, OnInit } from '@angular/core';
import { NbIconConfig, NbMenuItem } from '@nebular/theme';
import { BreakpointService } from './core/breakpoint.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'client';
  items: NbMenuItem[] = [
    {
      title: 'Profile',
      icon: 'person-outline',
    },
    {
      title: 'Change Password',
      icon: 'lock-outline',
    },
    {
      title: 'Privacy Policy',
      icon: { icon: 'checkmark-outline', pack: 'eva' },
    },
    {
      title: 'Logout',
      icon: 'unlock-outline',
    },
  ];
  
  tabs = [
    {
      title: 'Route tab #1',
      route: '/pages/description',
      icon: 'home',
      responsive: true, // hide title before `$tabset-tab-text-hide-breakpoint` value
    },
    {
      title: 'Route tab #2',
      route: '/pages/images',
      }
    ];

  constructor(
    public breakpoint: BreakpointService
  ) {}

  ngOnInit() {
    
  }

  updateSingleSelectGroupValue(value: any): void {
    // this.singleSelectGroupValue = value;
    console.log(value);
    // this.cd.markForCheck();
  }

  globeAction() {
    console.log("globe action")
  }

  crewAction() {
    console.log("globe action")
  }

  settingsAction() {
    console.log("globe action")
  }
}
