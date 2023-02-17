import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-boss-details',
  templateUrl: './boss-details.component.html',
  styleUrls: ['./boss-details.component.css']
})
export class BossDetailsComponent {
  weakness: string = "";
  index: number = -1;
  name: string = "N/A";
  constructor(private route: ActivatedRoute){}
  ngOnInit(): void {
    this.name = this.route.snapshot.params['name'];
  }


}
