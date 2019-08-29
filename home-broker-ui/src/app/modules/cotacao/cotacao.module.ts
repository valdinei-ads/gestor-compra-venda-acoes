import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'
import { ReactiveFormsModule } from '@angular/forms';

//  Components
import { CotacaoListComponent } from './components/cotacao-list/cotacao-list.component';
import { CotacaoCreateComponent } from './components/cotacao-create/cotacao-create.component';
import { CotacaoEditComponent } from './components/cotacao-edit/cotacao-edit.component';
import { CotacaoDetailsComponent } from './components/cotacao-details/cotacao-details.component';

//  Route Module
import { CotacaoRoutingModule } from './cotacao.routing.module';

@NgModule({
  declarations: [CotacaoListComponent, CotacaoCreateComponent, CotacaoEditComponent, CotacaoDetailsComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CotacaoRoutingModule
  ]
})
export class CotacaoModule { }