import { Component, OnInit } from '@angular/core';
import { ItemInterface } from './interfaces/item.interface';
import { ItemService } from './services/item.service';
import { faCheck } from '@fortawesome/free-solid-svg-icons';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FactorialInterface } from './interfaces/factorial.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  title = 'frontend';
  check = faCheck;
  items: ItemInterface[] = [];
  factorials: FactorialInterface[] = [];
  isModalOpen: boolean = false;
  itemForm: FormGroup;

  readonly columns = ['id', 'name', 'description', 'createdAt', 'factorial'];

  isLoading: boolean = false;

  constructor(
    private itemService: ItemService,
    private formB: FormBuilder,
  ) {
    this.itemForm = this.formB.group({
      itemName: ['', [Validators.required]],
      itemDescription: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.getItems();
    this.getFactorial();
  }

  showDialog() {
    console.log(this.isModalOpen);
    this.isModalOpen = true;
    console.log(this.isModalOpen);
  }

  closeModal() {
    this.isModalOpen = false;
  }

  getItems() {
    this.itemService.getItems().subscribe({
      next: (res: Array<ItemInterface>) => {
        this.items = res;
      },
      error: (error) => {
        alert('Failed get items. Please retry');
      },
    });
  }

  onSubmit(): void {
    if (this.itemForm.invalid) {
      this.itemForm.markAllAsTouched();
      return;
    }
    this.itemForm.disable();
    this.itemService.addItem(this.itemForm.value).subscribe({
      next: (res: ItemInterface) => {
        this.itemForm.reset();
        this.closeModal();
        this.items = [...this.items, res];
        alert('Item created successfully');
      },
      error: (error) => {
        alert('Failed create item. Please retry');
      },
    });
  }

  getFactorial() {
    this.itemService.getFactorials().subscribe({
      next: (res: Array<FactorialInterface>) => {
        this.factorials = res;
        this.items = this.items.map((it) => {
          it.factorial = this.factorials.find(
            (fc) => String(fc.itemId) === String(it.id),
          )?.factorial;
          return it;
        });
      },
      error: () => {
        alert('Failed to calculate Factorial. Please retry');
      },
    });
  }
}
