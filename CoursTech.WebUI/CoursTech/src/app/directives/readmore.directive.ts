import { Directive, ElementRef, HostBinding, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[app-Readmore]'
})
export class ReadmoreDirective implements OnInit {
  @Input() wordsNumber: number = 25;
  @Input() endingString: string = '...';
  // @HostBinding('value') text: string | undefined;

  constructor(private elementRef: ElementRef) { }
  ngOnInit(): void {
    // let readmoreElement:HTMLAnchorElement= document.createElement('a');
    // debugger;
    let text = this.elementRef.nativeElement.innerText;
    let words = text.split(' ');
    if (this.wordsNumber < words.length) {
      this.elementRef.nativeElement.innerText = words.slice(0, this.wordsNumber - 1).join(' ') + this.endingString;
      // this.elementRef.nativeElement.removeChild(this.elementRef.nativeElement.querySelectorAll('br'))
      this.elementRef.nativeElement.insertAdjacentHTML('beforeend',
        `<a style="font-size: smaller;cursor:pointer" class="fw-bold" [routerLink]="['/Course', course.courseId]">
          read more
        </a>`);
    }

  }

}
