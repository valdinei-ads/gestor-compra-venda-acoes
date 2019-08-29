import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class CalculadoraTaxaCorretagemService {

    calcularTaxaCorretagem(tipoOrdem: string, tipoPessoa: string, valorOrdem: number) {
        switch (tipoOrdem) {
            case 'C':
                switch (tipoPessoa) {
                    case 'F':
                        if (valorOrdem >= 2000000) {
                            return valorOrdem * 0o75;
                        } else {
                            return 0;
                        }
                        break;
                    case 'J':
                        if (valorOrdem >= 2000000) {
                            return valorOrdem * 0.45;
                        } else {
                            return valorOrdem * 0.25;
                        }
                        break;
                    default:
                }
                break;
            case 'V':
                switch (tipoPessoa) {
                    case 'F':
                        return valorOrdem * 0.70;
                        break;
                    case 'F':
                        return valorOrdem * 0.60;
                        break;
                    default:
                }
                break;
            default:
        }
    }
}