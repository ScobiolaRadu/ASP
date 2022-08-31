import { Injectable } from '@angular/core';

const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class StorageService {
  constructor() {}

  clean(): void {
    window.sessionStorage.clear();
  }

  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    if(user != null){
    let userData = user.split('.')[1]
    let decodedJwtJsonData = window.atob(userData)
    let decodedJwtData = JSON.parse(decodedJwtJsonData)
    let isAdmin = decodedJwtData.exp

    console.log(userData);
    console.log(decodedJwtJsonData);
    console.log(decodedJwtData);
    console.log(isAdmin);

    }

    if (user) {
      return JSON.parse(user);
    }

    return {};
  }

  public isLoggedIn(): boolean {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return true;
    }

    return false;
  }
}
