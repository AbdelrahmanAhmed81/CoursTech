import { Directive, ElementRef, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Directive({
  selector: '[app-Readmore]'
})
export class ReadmoreDirective implements OnInit {
  @Input() wordsNumber: number = 25;
  @Input() endingString: string = '...';
  @Input() readmoreNavigateCommands: string[] = [];

  constructor(private elementRef: ElementRef, private router: Router) { }
  ngOnInit(): void {
    let element = this.elementRef.nativeElement;

    let text = element.innerText;
    let words = text.split(' ');
    if (this.wordsNumber < words.length) {
      element.innerText = words.slice(0, this.wordsNumber - 1).join(' ') + this.endingString;

      let readmoreLink = document.createElement('a');
      readmoreLink.innerText = 'read more'
      readmoreLink.style.fontSize = 'smaller';
      readmoreLink.style.cursor = 'pointer';
      readmoreLink.classList.add('fw-bold');
      readmoreLink.addEventListener('click', () => {
        this.router.navigate(this.readmoreNavigateCommands)
      })

      element.appendChild(readmoreLink);
    }

  }

}
