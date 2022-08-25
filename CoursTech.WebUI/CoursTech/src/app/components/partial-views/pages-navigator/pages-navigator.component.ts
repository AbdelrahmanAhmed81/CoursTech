import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pages-navigator',
  templateUrl: './pages-navigator.component.html',
  styleUrls: ['./pages-navigator.component.css']
})
export class PagesNavigatorComponent implements OnInit {

  @Output() changePaginagtionEvent: EventEmitter<{ pageNumber: number, itemsPerPage: number }>
    = new EventEmitter<{ pageNumber: number, itemsPerPage: number }>();
  @Input() itemsTotalCount: number = 0;

  itemsPerPage: number = 5;
  pageNumber: number = 1;
  totalPages: number = 1;

  isNextEnable: boolean = true;
  isPreviousEnable: boolean = true;

  constructor() {
  }

  ngOnChanges() {
    if (this.itemsTotalCount != 0) {
      this.updateNav();
    }
  }

  ngOnInit(): void {

  }

  goBack() {
    if (this.isPreviousEnable) {
      this.pageNumber--;
      this.isNextEnable = this.pageNumber < this.totalPages;
      this.isPreviousEnable = this.pageNumber > 1;
      this.emitChanges();
    }
  }

  goForword() {
    if (this.isNextEnable) {
      this.pageNumber++;
      this.isNextEnable = this.pageNumber < this.totalPages;
      this.isPreviousEnable = this.pageNumber > 1;
      this.emitChanges();
    }
  }

  updateNav() {
    if (this.itemsTotalCount >= this.itemsPerPage)
      this.totalPages = this.itemsTotalCount / this.itemsPerPage;
    else
      this.totalPages = 1;

    if (this.pageNumber > this.totalPages) {
      this.pageNumber = this.totalPages;
    }
    this.isNextEnable = this.pageNumber < this.totalPages;
    this.isPreviousEnable = this.pageNumber > 1;
  }

  emitChanges() {
    this.changePaginagtionEvent.emit({ pageNumber: this.pageNumber, itemsPerPage: this.itemsPerPage });
  }

  onSelectItemsPerPage() {
    this.updateNav();
    //Bug: emit changes will fire ngOnChanges which will execute updateNav again
    //this bug will be visible in filteration and search because the itemsTotalCount will be changed
    this.emitChanges();
  }

}
