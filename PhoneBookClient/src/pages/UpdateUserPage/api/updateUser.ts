import {client} from "@/shared/api";
import type {UserDto} from "@/pages/UsersPage/model/types.ts";
import type {UserUpdateDto} from "@/pages/UpdateUserPage/model/types.ts";

export async function updateUser(
    data: UserUpdateDto
): Promise<UserDto> {
    try {
        const response = await client.put(`/User/update/`, data);
        return response.data;
    } catch (error) {
        console.error('Error updating user:', error);
        throw error;
    }
}