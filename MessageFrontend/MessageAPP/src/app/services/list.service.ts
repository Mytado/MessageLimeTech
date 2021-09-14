import { Injectable } from '@angular/core';
import { Message } from 'src/app/models/message.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ListService {
  private url: string = "http://localhost:55042/api/messages";

  constructor(private http: HttpClient) {}

  public deleteMessage(id: number) {
    return this.http.delete(this.url + "/" + id);
  }

  public getMessages() {
    return this.http.get<Message[]>(this.url);
  }

  public getMessageDetails(id: number) {
    return this.http.get<Message>(this.url + "/" + id);
  }

  public findMessage(input: string) {
    return this.http.get<Message[]>(this.url + "?search=" + input)
  }
}
