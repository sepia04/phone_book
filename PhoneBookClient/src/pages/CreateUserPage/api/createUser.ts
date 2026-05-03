import {client} from "@/shared/api";
import type {UserCreateDto} from "@/pages/CreateUserPage/model/types.ts";
import type {UserDto} from "@/pages/UsersPage/model/types.ts";

export async function createUser(data: UserCreateDto): Promise<UserDto> {
    try {
        const response = await client.post('/User/create', data);
        return response.data;
    } catch (error) {
        console.error('Error creating user:', error);
        throw error;
    }
}
