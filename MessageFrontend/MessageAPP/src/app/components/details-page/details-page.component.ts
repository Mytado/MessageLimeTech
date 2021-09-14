import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Message } from 'src/app/models/message.model';
import { ListService } from 'src/app/services/list.service';

@Component({
  selector: 'app-details-page',
  templateUrl: './details-page.component.html',
  styleUrls: ['./details-page.component.css']
})
export class DetailsPageComponent implements OnInit {
  messageId: number | undefined;
  message: Message | undefined;

  constructor(private readonly listService: ListService, private readonly route: ActivatedRoute, private readonly router: Router) { }

  ngOnInit(): void {
    this.messageId = Number(this.route.snapshot.url[1].toString());
    if(this.messageId == null) {
      this.router.navigateByUrl("/start");
    }
    
    this.listService.getMessageDetails(this.messageId)
      .subscribe((data: Message) => {
        this.message = data;
      });
  }

  returnToMain() {
    this.router.navigateByUrl("");
  }

  deleteMessage() {
    if(confirm("Are you sure to delete this message?")) {
      this.listService.deleteMessage(this.message!.id).subscribe();
      this.router.navigateByUrl("");
    }
  }
}
