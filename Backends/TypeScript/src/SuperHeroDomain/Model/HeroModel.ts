import { Entity, PrimaryGeneratedColumn, Column } from "typeorm";

// The property "name" sets the table name. This is usually implied from the
// class name, however this can be overridden if needed.
@Entity('hero')
export class Hero {
  @Column()
  id!: number;
  
  @PrimaryGeneratedColumn()
  public_id!: string;

  @Column()
  api_id!: number;

  @Column()
  name!: string;
}