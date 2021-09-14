import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Message } from 'src/app/models/message.model';
import { ListService } from 'src/app/services/list.service';

@Component({
  selector: 'app-start-page',
  templateUrl: './start-page.component.html',
  styleUrls: ['./start-page.component.css']
})
export class StartPageComponent implements OnInit {
  //newListEvent: Message[];
  //@Input() receiveListEvent = new EventEmitter<Message[]>();
  //@Input() receiveListEvent: Message[] | undefined;
  sendListEvent: Message[] | undefined;
  allMessages: Message[] = [];
  messageDetails: Message | undefined;

  constructor(private readonly listService: ListService, private readonly router: Router) { }

  sendEventToListComp(data: any) {
    this.sendListEvent = data;
  }

  receiveMessageDetail(data: any) {
    this.router.navigateByUrl("details/" + data);
  }

  deleteMessage(messsage: Message){
    this.listService
      .deleteMessage(messsage.id)
      .subscribe();
  }

  ngOnInit(): void {
    this.getMessages();
    
  }

  getMessages() {
    this.listService.getMessages()
      .subscribe((data: Message[]) => {
        this.allMessages = data;
        this.sendListEvent = data;
      });
  }

  getMessage(id: number) {
    this.listService.getMessageDetails(id)
      .subscribe((data: Message) => {
        this.messageDetails = data;
      });
  }
}
