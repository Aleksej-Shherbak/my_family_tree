export interface Person {
    id: number,
    firstName: string,
    lastName: string|null,
    isMale: boolean|null,
    birthdayDate: Date|null,
    previewImage: string|null,
    image: string|null
}