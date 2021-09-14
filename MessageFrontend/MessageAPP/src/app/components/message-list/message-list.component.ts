import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Message } from 'src/app/models/message.model';

@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent implements OnInit {
  @Input() searchMessagesEvent: Message[] | undefined;
  @Output() messageDetailIdEvent = new EventEmitter<number>();

  messages: Message[] = [];
  searchMessages: Message[] = [];
  messageDetails: Message | undefined;
  isSearched: boolean = false;

  constructor() {}
  ngOnInit(): void {
  }

  clickOnMessage(id: number) {
     this.messageDetailIdEvent.emit(id);
  }
}
