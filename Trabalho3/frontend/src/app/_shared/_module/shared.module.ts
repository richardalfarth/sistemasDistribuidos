import { LOCALE_ID, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TituloComponent } from '../titulo/titulo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, DatepickerModule, ModalModule, TabsetComponent, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';
import { NgxMaskModule } from 'ngx-mask';
import { NgxCurrencyModule } from 'ngx-currency';
import { DateTimeFormatPipe } from '../../_helps/DateTimeFormatPipe.pipe';



@NgModule({
  declarations: [
    TituloComponent,
    DateTimeFormatPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    DatepickerModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot(),
    TabsModule.forRoot(),
    NgxMaskModule.forRoot(),
    ReactiveFormsModule,
    NgxCurrencyModule
  ],
  exports: [
    CommonModule,
    TituloComponent, 
    DateTimeFormatPipe,
    FormsModule,
    BsDatepickerModule,
    DatepickerModule,
    BsDropdownModule,
    TooltipModule,
    ModalModule,
    ToastrModule,
    TabsModule,
    NgxMaskModule,
    ReactiveFormsModule,
    NgxCurrencyModule],
    
    providers: [{ provide: LOCALE_ID, useValue: 'pt-br'}],
})
export class SharedModule { }
