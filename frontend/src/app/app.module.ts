import {
  TuiRootModule,
  TuiDialogModule,
  TuiAlertModule,
  TuiHintModule,
  TuiTextfieldControllerModule,
  TuiButtonModule,
  TuiErrorModule,
} from '@taiga-ui/core';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TuiSortByDirective, TuiTableModule } from '@taiga-ui/addon-table';
import { TuiLetModule } from '@taiga-ui/cdk';
import { TuiInputModule } from '@taiga-ui/kit';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    FormsModule,
    TuiRootModule,
    TuiDialogModule,
    TuiAlertModule,
    TuiTableModule,
    TuiLetModule,
    ReactiveFormsModule,
    TuiInputModule,
    TuiHintModule,
    TuiTextfieldControllerModule,
    TuiButtonModule,
    TuiErrorModule,
  ],
  providers: [TuiSortByDirective],
  bootstrap: [AppComponent],
})
export class AppModule {}
