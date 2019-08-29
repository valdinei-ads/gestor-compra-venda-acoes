import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

//  Components
import { OrdemListComponent } from './components/ordem-list/ordem-list.component';
import { OrdemCreateComponent } from './components/ordem-create/ordem-create.component';
import { OrdemDetailsComponent } from './components/ordem-details/ordem-details.component';

//  Route Module
import { OrdemRoutingModule } from './ordem.routing.module';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [OrdemListComponent, OrdemCreateComponent, OrdemDetailsComponent],
  imports: [
    CommonModule,
    OrdemRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class OrdemModule { }