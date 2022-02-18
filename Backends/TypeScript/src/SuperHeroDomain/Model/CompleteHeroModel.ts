import { Entity, PrimaryGeneratedColumn, Column } from "typeorm";

// The property "name" sets the table name. This is usually implied from the
// class name, however this can be overridden if needed.
@Entity('complete_hero')
export class CompleteHero {
  @PrimaryGeneratedColumn()
  PUBLIC_ID!: string;

  @Column({ type: 'json'})
  HERO!: string;
}