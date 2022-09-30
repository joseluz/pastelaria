import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'pa-qty-selector',
  templateUrl: './qty-selector.component.html',
  styleUrls: ['./qty-selector.component.css']
})
export class QtySelectorComponent implements OnInit {
  @Input() value: number = 0;
  @Output() valueChange = new EventEmitter<number>();
  @Input() flavor: string = '';

  constructor() {
  }

  ngOnInit(): void {
  }

  add(): void {
    this.value++;
    this.valueChange.emit(this.value);
  }

  substract(): void {
    if (this.value >= 1) {
      this.value--;
      this.valueChange.emit(this.value);
    }
  }
}
