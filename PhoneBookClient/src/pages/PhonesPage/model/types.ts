import type {UserDto} from "@/pages/UsersPage/model/types.ts";

export interface PhoneDto {
    id: number;
    phoneNumber: string;
    user: UserDto
}