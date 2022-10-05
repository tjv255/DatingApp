import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, pipe } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';
import { PaginatedResult } from '../_models/pagination';
import { User } from '../_models/user';
import { UserParams } from '../_models/userParams';
import { AccountService } from './account.service';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';

@Injectable({
    providedIn: 'root'
})
export class MembersService {
    baseUrl = environment.apiUrl;
    members: Member[] = [];
    memberCache = new Map();
    user: User;
    userParams: UserParams;
    currMem: Member;

    getUserParams() {
        return this.userParams
    }

    setUserParams(params: UserParams) {
        this.userParams = params;
    }

    resetUserParams() {
        this.userParams = new UserParams(this.user);
        return this.userParams;
    }

    constructor(private http: HttpClient, private accountService: AccountService) {
        this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
            this.user = user;
            this.userParams = new UserParams(user);
            this.getMember(user.username).subscribe(member =>{
                this.currMem = member;
            });
        })        
    }

    getMembers(userParams: UserParams) {
        var response = this.memberCache.get(Object.values(userParams).join('-'));
        if (response) {
            return of(response);
        }

        let params = getPaginationHeaders(userParams.pageNumber, userParams.pageSize);

        params = params.append('city', userParams.city);
        params = params.append('provinceOrState', userParams.provinceOrState);
        params = params.append('country', userParams.country);
        params = params.append('occupation', userParams.occupation);
        params = params.append('skill', userParams.skill);
        params = params.append('genre', userParams.genre);
        params = params.append('orderBy', userParams.orderBy);

        return getPaginatedResult<Member[]>(this.baseUrl + 'users', params, this.http)
            .pipe(map(response => {
                this.memberCache.set(Object.values(userParams).join('-'), response);
                return response;
            }));
    }

    getMember(username: string) {
        const member = [...this.memberCache.values()]
            .reduce((arr, elem) => arr.concat(elem.result), [])
            .find((member: Member) => member.username === username);

        if (member) {
            console.log(member);
            return of(member);
        }
        return this.http.get<Member>(this.baseUrl + 'users/' + username);
    }

    //Make sure its supported by back end
    getMemberbyId(id: number) {
        const member = [...this.memberCache.values()]
            .reduce((arr, elem) => arr.concat(elem.result), [])
            .find((member: Member) => member.id === id);

        if (member) {
            return of(member);
        }
        return this.http.get<Member>(this.baseUrl + 'users/' + id);
    }


    updateMember(member: Member) {
        return this.http.put(this.baseUrl + 'users', member).pipe(
            map(() => {
                const index = this.members.indexOf(member);
                this.members[index] = member;
            })
        );
    }

    setMainPhoto(photoId: number) {
        return this.http.put(this.baseUrl + 'users/set-main-photo/' + photoId, {});
    }

    deletePhoto(photoId: number) {
        return this.http.delete(this.baseUrl + 'users/delete-photo/' + photoId, {})
    }

    addLike(username: string) {
        return this.http.post(this.baseUrl + 'likes/' + username, {});
    }

    getLikes(predicate: string, pageNumber, pageSize) {
        let params = getPaginationHeaders(pageNumber, pageSize);
        params = params.append('predicate', predicate);
        return getPaginatedResult<Partial<Member[]>>(this.baseUrl + 'likes', params, this.http);
    }


}
