"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
/** source/routes/posts.ts */
const express_1 = __importDefault(require("express"));
const posts_1 = __importDefault(require("../SuperHeroApi/controllers/posts"));
const heroController_1 = __importDefault(require("../SuperHeroApi/controllers/heroController"));
const completeheroController_1 = __importDefault(require("../SuperHeroApi/controllers/completeheroController"));
const router = express_1.default.Router();
router.get('/get_complete_hero/:public_hero_id', completeheroController_1.default.getCompletHero);
router.get('/list_all_heroes_with_pagination', heroController_1.default.getAllHeroesPaginated);
router.get('/list_all_heroes', heroController_1.default.listAllHeroes);
router.get('/posts', posts_1.default.getPosts);
router.get('/posts/:id', posts_1.default.getPost);
router.put('/posts/:id', posts_1.default.updatePost);
router.delete('/posts/:id', posts_1.default.deletePost);
router.post('/posts', posts_1.default.addPost);
module.exports = router;
