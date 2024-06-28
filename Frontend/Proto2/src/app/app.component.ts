import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeCareListComponent } from './components/home-care-list/home-care-list.component';
import { NavComponent } from './shared/nav/nav.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HomeCareListComponent, NavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Proto2';
}
