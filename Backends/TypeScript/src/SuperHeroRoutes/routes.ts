/** source/routes/posts.ts */
import express from 'express';
import controller from '../SuperHeroApi/controllers/posts';
import heroController from '../SuperHeroApi/controllers/heroController';
import completeheroController from '../SuperHeroApi/controllers/completeheroController';
const router = express.Router();

router.get('/get_complete_hero/:public_hero_id', completeheroController.getCompletHero);
router.get('/list_all_heroes_with_pagination', heroController.getAllHeroesPaginated);
router.get('/list_all_heroes', heroController.listAllHeroes);
router.get('/posts', controller.getPosts);
router.get('/posts/:id', controller.getPost);
router.put('/posts/:id', controller.updatePost);
router.delete('/posts/:id', controller.deletePost);
router.post('/posts', controller.addPost);

export = router;