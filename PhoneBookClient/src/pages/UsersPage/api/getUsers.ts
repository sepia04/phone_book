import {client} from '@/shared/api';
import type {UserDto} from "../model/types.ts";

export function getUsers() {
    return client.get<UserDto[]>("/User/users");
}