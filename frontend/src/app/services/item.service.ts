import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ItemInterface } from '../interfaces/item.interface';
import { environment } from '../../../environment/environment';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  constructor(private http: HttpClient) {}

  getItems(): Observable<Array<ItemInterface>> {
    return this.http.get<Array<ItemInterface>>(
      environment.backendUrl + '/items',
    );
  }
}
