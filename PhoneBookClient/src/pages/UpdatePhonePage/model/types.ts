import type {UserDto} from "@/pages/UsersPage/model/types.ts";

export interface PhoneUpdateDto {
    id: number;
    phoneNumber?: string;
    user: UserDto;
}