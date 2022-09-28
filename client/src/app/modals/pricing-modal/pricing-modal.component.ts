import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pricing',
  templateUrl: './pricing-modal.component.html',
  styleUrls: ['./pricing-modal.component.css']
})
export class PricingModalComponent implements OnInit {
    @Output() registerToggle = new EventEmitter();

  constructor() { }
  fortissimoPrice: number = 29;
  fortePrice: number = 15;

  ngOnInit(): void {
  }

  registerMode() {
    this.registerToggle.emit(true);
  }
}
