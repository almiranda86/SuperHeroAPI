import axios from 'axios';
import {API_URI, API_TOKEN} from "../../SuperHeroCore/Config/Constants";


export class HeroLookup {

    async getAllHeroes(sender: object) {

        const URL = `${API_URI}${API_TOKEN}`;

        const response = Promise.resolve(await axios.get(`${URL}/1`))
                        .then((promiseResponse) => promiseResponse.data)
                        .then((posts) => { 
                            return posts;
                         });

        return response;
    }
}