import { Component,EventEmitter,Output } from '@angular/core';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent {
  @Output() filterChange = new EventEmitter<string>();
  selectedFilter: string = '';
  applyFilter() {
    this.filterChange.emit(this.selectedFilter);
  }

}
