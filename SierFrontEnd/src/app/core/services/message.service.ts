import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable()
export class MessageService {
    private idMsg = new BehaviorSubject(0);
    sharedMessage = this.idMsg.asObservable();

    constructor() { }

    nextId(message: number) {
        this.idMsg.next(message);
    }

    public getId(): Observable<number> {
        return this.idMsg.asObservable();
    }
}