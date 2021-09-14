import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Message } from 'src/app/models/message.model';
import { ListService } from 'src/app/services/list.service';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {
  search: string = "";
  searchMessages: Message[] = [];

  constructor(
    private readonly listService: ListService,
  ) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    this.search = form.value.search;
    this.listService.findMessage(this.search)
      .subscribe((data: Message[]) => {
        this.searchMessages = data
        this.addNewList(this.searchMessages);
      });
  }

  @Output() newListEvent = new EventEmitter<Message[]>();

  addNewList(value: Message[]) {
    this.newListEvent.emit(value);
  }
}
