import { TestBed, inject } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { ItemService } from './item.service';
import { ItemInterface } from '../interfaces/item.interface';
import { FactorialInterface } from '../interfaces/factorial.interface';
import { environment } from '../../../environment/environment';

describe('ItemService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ItemService],
    });
  });

  it('should be created', () => {
    const service: ItemService = TestBed.get(ItemService);
    expect(service).toBeTruthy();
  });

  it('should get items', inject(
    [HttpTestingController, ItemService],
    (httpMock: HttpTestingController, itemService: ItemService) => {
      const mockItems: ItemInterface[] = [
        {
          id: 1,
          itemId: '1',
          itemName: 'Item 1',
          itemDescription: 'Description 1',
          createdDtm: '',
        },
        {
          id: 2,
          itemId: '2',
          itemName: 'Item 2',
          itemDescription: 'Description 2',
          createdDtm: '',
        },
      ];

      itemService.getItems().subscribe((items) => {
        expect(items).toBeTruthy();
        expect(items.length).toBe(2);
        expect(items).toEqual(mockItems);
      });

      const req = httpMock.expectOne(`${environment.backendUrl}/items`);
      expect(req.request.method).toBe('GET');
      req.flush(mockItems);

      httpMock.verify();
    },
  ));

  it('should add item', inject(
    [HttpTestingController, ItemService],
    (httpMock: HttpTestingController, itemService: ItemService) => {
      const newItem: ItemInterface = {
        id: 3,
        itemId: '3',
        itemName: 'Item 3',
        itemDescription: 'Description 3',
        createdDtm: '',
      };

      itemService.addItem(newItem).subscribe((item) => {
        expect(item).toBeTruthy();
        expect(item).toEqual(newItem);
      });

      const req = httpMock.expectOne(`${environment.backendUrl}/items`);
      expect(req.request.method).toBe('POST');
      req.flush(newItem);

      httpMock.verify();
    },
  ));

  it('should get factorials', inject(
    [HttpTestingController, ItemService],
    (httpMock: HttpTestingController, itemService: ItemService) => {
      const mockFactorials: FactorialInterface[] = [
        { itemId: 1, factorial: '120' },
        { itemId: 2, factorial: '720' },
      ];

      itemService.getFactorials().subscribe((factorials) => {
        expect(factorials).toBeTruthy();
        expect(factorials.length).toBe(2);
        expect(factorials).toEqual(mockFactorials);
      });

      const req = httpMock.expectOne(
        `${environment.backendUrl}/items/factorial`,
      );
      expect(req.request.method).toBe('GET');
      req.flush(mockFactorials);

      httpMock.verify();
    },
  ));
});
