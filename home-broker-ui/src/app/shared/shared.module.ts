import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormDebugComponent } from './components/form-debug/form-debug.component';
import { HeaderComponent } from './components/header/header.component';

@NgModule({
    declarations: [
        FormDebugComponent,
        HeaderComponent
    ],
    imports: [
      CommonModule,  
    ],
    exports:[
        FormDebugComponent
    ]
})
export class SharedModule{}