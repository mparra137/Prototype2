import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card'

@Component({
  selector: 'app-home-care-list',
  standalone: true,
  imports: [MatCardModule],
  templateUrl: './home-care-list.component.html',
  styleUrl: './home-care-list.component.scss'
})
export class HomeCareListComponent {

}
