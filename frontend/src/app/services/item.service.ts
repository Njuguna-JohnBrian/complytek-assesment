import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ItemInterface } from '../interfaces/item.interface';
import { environment } from '../../../environment/environment';
import { FactorialInterface } from '../interfaces/factorial.interface';

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

  addItem(itemData: ItemInterface): Observable<ItemInterface> {
    return this.http.post<ItemInterface>(
      environment.backendUrl + '/items',
      itemData,
    );
  }

  getFactorials(): Observable<Array<FactorialInterface>> {
    return this.http.get<Array<FactorialInterface>>(
      environment.backendUrl + '/items/factorial',
    );
  }
}
