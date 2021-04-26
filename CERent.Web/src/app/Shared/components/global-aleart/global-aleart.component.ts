import { Component, OnInit } from '@angular/core';
import { GlobalAleart, GlobalAleartTypes } from '../../models/GlobalAleart';
import { GlobalAleartService } from '../../services/global-aleart.service';

@Component({
  selector: 'app-global-aleart',
  templateUrl: './global-aleart.component.html',
  styleUrls: ['./global-aleart.component.scss']
})
export class GlobalAleartComponent implements OnInit {

  public _globalAleartTypes = GlobalAleartTypes; 

  constructor(private _globalAleartService: GlobalAleartService) { }

  public alerts: GlobalAleart[] = []

  ngOnInit() {

    this._globalAleartService.onAlearUpdate().subscribe(x => {
      this.alerts = x;
    });
  }

  public getClassByType(globalAleartType: GlobalAleartTypes): string{

    switch(globalAleartType)
    {
      case GlobalAleartTypes.Danger: "alert-danger"; break;
      case GlobalAleartTypes.Info: "alert-info"; break;
      case GlobalAleartTypes.Success: "alert-success"; break;
      case GlobalAleartTypes.Warning: "alert-warning"; break;
    }

    return "";

  }

  public removeAleart(globalAleart: GlobalAleart){
    this._globalAleartService.removeAleart(globalAleart);
  }

}
