import { Injectable } from '@angular/core';
import { List } from 'linqts';
import { Observable, of, Subject } from 'rxjs';
import { GlobalAleart, GlobalAleartTypes } from '../models/GlobalAleart';

@Injectable({
  providedIn: 'root'
})
export class GlobalAleartService {

private _alearts : List<GlobalAleart>;
private _aleartSubject: Subject<GlobalAleart[]>;

/* public Aleart():string[]{
  get:{
    return this._alears.ToArray();
  }
} */

constructor() { 
  this._alearts = new List<GlobalAleart>();
  this._aleartSubject = new Subject<GlobalAleart[]>();

 /*  setTimeout(() => {
    var a = <GlobalAleart>{Message: "this is a test", GlobalAleartType: GlobalAleartTypes.Info};
    this.addAleart(a);
  }, 5000);  */
}
  
public addAleart(alert: GlobalAleart): void{
  this._alearts.Add(alert);
  this._aleartSubject.next(this._alearts.ToArray());
  
}

public removeAleart(alertToRemove: GlobalAleart){
  let alearttoRemoveList = this._alearts.Where(x => x?.GlobalAleartType == alertToRemove.GlobalAleartType && x?.Message == alertToRemove.Message).FirstOrDefault();
  
  if(alearttoRemoveList != null){
    this._alearts.Remove(alearttoRemoveList);
  }

}

public onAlearUpdate():Observable<GlobalAleart[]>{
  return this._aleartSubject;
}

}


