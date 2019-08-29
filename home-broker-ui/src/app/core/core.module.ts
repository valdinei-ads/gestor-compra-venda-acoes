import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalculadoraTaxaCorretagemService } from './service/calculadora-taxa-corretagem.service';

@NgModule({
  declarations: [CalculadoraTaxaCorretagemService],
  imports: [
    CommonModule
  ],
  exports: [
    CalculadoraTaxaCorretagemService
  ]
})
export class CoreModule { }
