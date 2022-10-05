import { Component, OnInit } from '@angular/core';
import { PastelService } from "../../services/pastel.services";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  flavors: Array<any> = [];
  unitValue: number = 7.00;

  constructor(private pastelService: PastelService) {
  }

  get total(): number {
    var qties = this.flavors.map(f => f.qty).reduce((curr, val) => curr + val, 0);
    return qties;
  }

  ngOnInit(): void {
    this.pastelService.findAllFlavors()
      .subscribe({
        next: (flavors) => {
          this.flavors = flavors;
        }
      })
  }

}
